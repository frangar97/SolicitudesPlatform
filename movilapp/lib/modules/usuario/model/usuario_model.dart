import 'package:equatable/equatable.dart';

class UsuarioModel extends Equatable {
  final int id;
  final String nombre;
  final String apellido;
  final String codigo;
  final String genero;
  final String tipoUsuario;
  final String? urlImagen;

  const UsuarioModel({
    required this.apellido,
    required this.codigo,
    required this.genero,
    required this.nombre,
    required this.tipoUsuario,
    required this.id,
    this.urlImagen,
  });

  factory UsuarioModel.fromJson(Map<String, dynamic> json) => UsuarioModel(
      apellido: json["apellido"],
      codigo: json["codigo"],
      genero: json["genero"],
      nombre: json["nombre"],
      tipoUsuario: json["tipoUsuario"],
      id: json["id"],
      urlImagen: json["urlImagen"]);

  UsuarioModel copyWith(
          {int? id,
          String? nombre,
          String? codigo,
          String? genero,
          String? tipoUsuario,
          String? apellido,
          String? urlImagen}) =>
      UsuarioModel(
        id: id ?? this.id,
        apellido: apellido ?? this.apellido,
        codigo: codigo ?? this.codigo,
        genero: genero ?? this.genero,
        nombre: nombre ?? this.nombre,
        tipoUsuario: tipoUsuario ?? this.tipoUsuario,
        urlImagen: urlImagen ?? this.urlImagen,
      );

  @override
  List<Object?> get props => [
        id,
        urlImagen,
        tipoUsuario,
        nombre,
        genero,
        apellido,
        codigo,
      ];
}
