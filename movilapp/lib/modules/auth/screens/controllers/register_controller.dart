import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/screens/states/register_state.dart';
import 'package:movilapp/modules/global/state_notifier.dart';

class RegisterController extends StateNotifier<RegisterState> {
  RegisterController(super.state, {required this.authenticationRepository});

  final AuthenticationRepository authenticationRepository;

  Future<void> init() async {
    final result = await authenticationRepository.obtenerGeneros();

    result.fold(
      (l) => null,
      (r) {
        updateAndNotify(state.copyWith(generos: r));
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

  void onGeneroChange(String genero) {
    updateAndNotify(state.copyWith(genero: genero));
  }

  void onTipoUsuarioChange(String tipoUsuario) {
    onlyUpdate(state.copyWith(tipoUsuario: tipoUsuario));
  }
}
