import 'package:equatable/equatable.dart';

class LoginState extends Equatable {
  final String codigo;
  final String password;
  final bool loading;

  const LoginState(
      {required this.codigo, required this.password, required this.loading});

  LoginState copyWith({String? codigo, String? password, bool? loading}) =>
      LoginState(
        codigo: codigo ?? this.codigo,
        password: password ?? this.password,
        loading: loading ?? this.loading,
      );

  @override
  List<Object?> get props => [
        codigo,
        password,
        loading,
      ];
}
