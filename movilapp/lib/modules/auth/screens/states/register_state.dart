import 'package:equatable/equatable.dart';
import 'package:movilapp/modules/auth/model/genero_model.dart';

class RegisterState extends Equatable {
  final String nombre;
  final String apellido;
  final String codigo;
  final String password;
  final String genero;
  final String tipoUsuario;
  final bool loading;
  final List<GeneroModel> generos;

  const RegisterState({
    required this.codigo,
    required this.password,
    required this.loading,
    required this.apellido,
    required this.genero,
    required this.nombre,
    required this.tipoUsuario,
    required this.generos,
  });

  RegisterState copyWith(
          {String? codigo,
          String? password,
          bool? loading,
          String? nombre,
          String? apellido,
          String? genero,
          String? tipoUsuario,
          List<GeneroModel>? generos}) =>
      RegisterState(
        codigo: codigo ?? this.codigo,
        password: password ?? this.password,
        loading: loading ?? this.loading,
        nombre: nombre ?? this.nombre,
        apellido: apellido ?? this.apellido,
        genero: genero ?? this.genero,
        tipoUsuario: tipoUsuario ?? this.tipoUsuario,
        generos: generos ?? this.generos,
      );

  @override
  List<Object?> get props => [
        codigo,
        password,
        loading,
        nombre,
        apellido,
        genero,
        tipoUsuario,
        generos
      ];
}
