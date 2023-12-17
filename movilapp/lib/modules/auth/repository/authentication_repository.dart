import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/auth/model/login_model.dart';

abstract class AuthenticationRepository {
  Future<Either<String, String>> login(LoginModel loginModel);
}
