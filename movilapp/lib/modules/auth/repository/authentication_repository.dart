import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/auth/model/genero_model.dart';
import 'package:movilapp/modules/auth/model/login_model.dart';

abstract class AuthenticationRepository {
  Future<Either<String, String>> login(LoginModel loginModel);
  Future<Either<String, List<GeneroModel>>> obtenerGeneros();
}
