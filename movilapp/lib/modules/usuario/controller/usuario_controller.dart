import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/global/state_notifier.dart';
import 'package:movilapp/modules/usuario/model/usuario_model.dart';
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
    updateAndNotify(state.copyWith(
      usuario: const UsuarioModel(
        apellido: "",
        codigo: "",
        genero: "",
        nombre: "",
        tipoUsuario: "",
        id: 0,
      ),
    ));
    await flutterSecureStorage.delete(key: "token");
  }

  Future<bool> existeSesion() async {
    final token = await flutterSecureStorage.read(key: "token");
    if (token == null) {
      return false;
    }

    return true;
  }
}
