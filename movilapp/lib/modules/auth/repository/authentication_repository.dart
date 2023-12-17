import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/auth/model/genero_model.dart';
import 'package:movilapp/modules/auth/model/login_model.dart';
import 'package:movilapp/modules/auth/model/tipo_usuario_model.dart';

abstract class AuthenticationRepository {
  Future<Either<String, String>> login(LoginModel loginModel);
  Future<Either<String, String>> registrarUsuarios(
      String nombre,
      String apellido,
      String codigo,
      String password,
      String genero,
      String tiposUsuario);
  Future<Either<String, List<GeneroModel>>> obtenerGeneros();
  Future<Either<String, List<TipoUsuarioModel>>> obtenerTiposUsuario();
}
