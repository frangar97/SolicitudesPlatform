import 'package:equatable/equatable.dart';

class LoginModel extends Equatable {
  final String codigo;
  final String password;

  const LoginModel({required this.codigo, required this.password});

  Map<String, dynamic> toJson() => {"codigo": codigo, "password": password};

  @override
  List<Object?> get props => [codigo, password];
}
