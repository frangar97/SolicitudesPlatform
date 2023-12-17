import 'package:movilapp/modules/auth/model/login_model.dart';

abstract class AuthenticationRepository {
  Future<void> login(LoginModel loginModel);
}
