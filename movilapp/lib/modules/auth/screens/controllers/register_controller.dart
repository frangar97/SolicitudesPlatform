import 'dart:io';

import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/screens/states/register_state.dart';
import 'package:movilapp/modules/global/state_notifier.dart';

class RegisterController extends StateNotifier<RegisterState> {
  RegisterController(super.state, {required this.authenticationRepository});

  final AuthenticationRepository authenticationRepository;

  Future<void> init() async {
    final resultGeneros = await authenticationRepository.obtenerGeneros();
    final resultTiposUsuario =
        await authenticationRepository.obtenerTiposUsuario();

    resultGeneros.fold(
      (l) => null,
      (r) {
        updateAndNotify(state.copyWith(generos: r));
      },
    );

    resultTiposUsuario.fold(
      (l) => null,
      (r) {
        updateAndNotify(state.copyWith(tiposUsuario: r));
      },
    );
  }

  void onCodigoChange(String codigo) {
    onlyUpdate(state.copyWith(codigo: codigo));
  }

  void onPasswordChange(String password) {
    onlyUpdate(state.copyWith(password: password));
  }

  void onNombreChange(String nombre) {
    onlyUpdate(state.copyWith(nombre: nombre));
  }

  void onApellidoChange(String apellido) {
    onlyUpdate(state.copyWith(apellido: apellido));
  }

  void onGeneroChange(String genero) {
    updateAndNotify(state.copyWith(genero: genero));
  }

  void onTipoUsuarioChange(String tipoUsuario) {
    updateAndNotify(state.copyWith(tipoUsuario: tipoUsuario));
  }

  void onChangeImage(File? imagen) {
    updateAndNotify(state.copyWith(file: imagen));
  }

  Future<Either<String, String>> registrarUsuario() async {
    updateAndNotify(state.copyWith(loading: true));
    final result = await authenticationRepository.registrarUsuarios(
      state.nombre,
      state.apellido,
      state.codigo,
      state.password,
      state.genero,
      state.tipoUsuario,
      state.file,
    );
    updateAndNotify(state.copyWith(loading: false));
    return result;
  }
}
