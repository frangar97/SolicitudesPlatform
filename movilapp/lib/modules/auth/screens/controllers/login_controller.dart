import 'package:dartz/dartz.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/auth/model/login_model.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/screens/states/login_state.dart';
import 'package:movilapp/modules/global/state_notifier.dart';

class LoginController extends StateNotifier<LoginState> {
  LoginController(super.state,
      {required this.authenticationRepository,
      required this.flutterSecureStorage});

  final AuthenticationRepository authenticationRepository;
  FlutterSecureStorage flutterSecureStorage;

  void onCodigoChange(String codigo) {
    onlyUpdate(state.copyWith(codigo: codigo));
  }

  void onPasswordChange(String password) {
    onlyUpdate(state.copyWith(password: password));
  }

  Future<Either<String, String>> iniciarSesion() async {
    updateAndNotify(state.copyWith(loading: true));

    final result = await authenticationRepository.login(LoginModel(
      codigo: state.codigo,
      password: state.password,
    ));

    updateAndNotify(state.copyWith(loading: false));

    return result;
  }

  Future<void> guardarTokenUsuario(String token) async {
    await flutterSecureStorage.write(key: "token", value: token);
  }
}
