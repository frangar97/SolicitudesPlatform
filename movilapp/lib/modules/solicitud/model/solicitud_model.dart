import 'package:equatable/equatable.dart';

class SolicitudModel extends Equatable {
  final int id;
  final String descripcion;
  final String usuario;
  final String estadoSolicitud;
  final String tipoSolicitud;
  final String zona;

  const SolicitudModel(
      {required this.id,
      required this.descripcion,
      required this.usuario,
      required this.estadoSolicitud,
      required this.tipoSolicitud,
      required this.zona});

  factory SolicitudModel.fromJson(Map<String, dynamic> json) => SolicitudModel(
        id: json["id"],
        descripcion: json["descripcion"],
        usuario: json["usuario"],
        estadoSolicitud: json["estadoSolicitud"],
        tipoSolicitud: json["tipoSolicitud"],
        zona: json["zona"],
      );

  SolicitudModel copyWith(
          {int? id,
          String? descripcion,
          String? usuario,
          String? estadoSolicitud,
          String? tipoSolicitud,
          String? zona}) =>
      SolicitudModel(
        id: id ?? this.id,
        descripcion: descripcion ?? this.descripcion,
        usuario: usuario ?? this.usuario,
        estadoSolicitud: estadoSolicitud ?? this.estadoSolicitud,
        tipoSolicitud: tipoSolicitud ?? this.tipoSolicitud,
        zona: zona ?? this.zona,
      );

  @override
  List<Object?> get props => [
        id,
        descripcion,
        usuario,
        estadoSolicitud,
        tipoSolicitud,
        zona,
      ];
}
