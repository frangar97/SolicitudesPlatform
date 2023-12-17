import 'package:equatable/equatable.dart';
import 'package:movilapp/modules/auth/model/genero_model.dart';
import 'package:movilapp/modules/auth/model/tipo_usuario_model.dart';

class RegisterState extends Equatable {
  final String nombre;
  final String apellido;
  final String codigo;
  final String password;
  final String genero;
  final String tipoUsuario;
  final bool loading;
  final List<GeneroModel> generos;
  final List<TipoUsuarioModel> tiposUsuario;

  const RegisterState({
    required this.codigo,
    required this.password,
    required this.loading,
    required this.apellido,
    required this.genero,
    required this.nombre,
    required this.tipoUsuario,
    required this.generos,
    required this.tiposUsuario,
  });

  RegisterState copyWith({
    String? codigo,
    String? password,
    bool? loading,
    String? nombre,
    String? apellido,
    String? genero,
    String? tipoUsuario,
    List<GeneroModel>? generos,
    List<TipoUsuarioModel>? tiposUsuario,
  }) =>
      RegisterState(
        codigo: codigo ?? this.codigo,
        password: password ?? this.password,
        loading: loading ?? this.loading,
        nombre: nombre ?? this.nombre,
        apellido: apellido ?? this.apellido,
        genero: genero ?? this.genero,
        tipoUsuario: tipoUsuario ?? this.tipoUsuario,
        generos: generos ?? this.generos,
        tiposUsuario: tiposUsuario ?? this.tiposUsuario,
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
        generos,
        tiposUsuario,
      ];
}
