import 'package:equatable/equatable.dart';

class CreateSolicitudModel extends Equatable {
  final String descripcion;
  final String tipoSolicitud;
  final String zona;

  const CreateSolicitudModel(
      {required this.descripcion,
      required this.tipoSolicitud,
      required this.zona});

  Map<String, dynamic> toJson() => {
        "descripcion": descripcion,
        "zona": zona,
        "tipoSolicitud": tipoSolicitud
      };

  @override
  List<Object?> get props => [descripcion, tipoSolicitud, zona];
}
