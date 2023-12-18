import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/global/state_notifier.dart';
import 'package:movilapp/modules/usuario/state/usuario_state.dart';

class UsuarioController extends StateNotifier<UsuarioState> {
  UsuarioController(super.state,
      {required this.authenticationRepository,
      required this.flutterSecureStorage});

  final AuthenticationRepository authenticationRepository;
  FlutterSecureStorage flutterSecureStorage;

  Future<void> init() async {
    final token = await flutterSecureStorage.read(key: "token");
    final result = await authenticationRepository.obtenerUsuario(token!);

    result.fold((l) => null, (r) {
      updateAndNotify(state.copyWith(usuario: r));
    });
  }

  Future<void> cerrarSesion() async {
    flutterSecureStorage.delete(key: "token");
  }
}
