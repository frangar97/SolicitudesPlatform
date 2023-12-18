import 'package:floor/floor.dart';

@Entity(tableName: "Usuario")
class UsuarioEntity {
  @PrimaryKey(autoGenerate: true)
  final int? id;
  final String nombre;
  final String apellido;
  final String codigo;
  final String genero;
  final String tipoUsuario;
  String? urlImagen;

  UsuarioEntity({
    required this.apellido,
    required this.codigo,
    required this.genero,
    required this.nombre,
    required this.tipoUsuario,
    this.id,
    this.urlImagen,
  });

  UsuarioEntity copyWith(
          {int? id,
          String? nombre,
          String? codigo,
          String? genero,
          String? tipoUsuario,
          String? apellido,
          String? urlImagen}) =>
      UsuarioEntity(
        id: id ?? this.id,
        apellido: apellido ?? this.apellido,
        codigo: codigo ?? this.codigo,
        genero: genero ?? this.genero,
        nombre: nombre ?? this.nombre,
        tipoUsuario: tipoUsuario ?? this.tipoUsuario,
        urlImagen: urlImagen ?? this.urlImagen,
      );
}
