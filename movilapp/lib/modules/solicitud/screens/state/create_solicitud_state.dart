import 'package:equatable/equatable.dart';
import 'package:movilapp/modules/solicitud/model/tipo_solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/zona_model.dart';

class CreateSolicitudState extends Equatable {
  final String descripcion;
  final String tipoSolicitud;
  final String zona;
  final List<TipoSolicitudModel> tiposSolicitud;
  final List<ZonaModel> zonas;
  final bool loading;

  const CreateSolicitudState(
      {required this.descripcion,
      required this.tipoSolicitud,
      required this.tiposSolicitud,
      required this.zona,
      required this.zonas,
      required this.loading});

  CreateSolicitudState copyWith(
          {String? descripcion,
          String? tipoSolicitud,
          String? zona,
          List<TipoSolicitudModel>? tiposSolicitud,
          List<ZonaModel>? zonas,
          bool? loading}) =>
      CreateSolicitudState(
          descripcion: descripcion ?? this.descripcion,
          tipoSolicitud: tipoSolicitud ?? this.tipoSolicitud,
          tiposSolicitud: tiposSolicitud ?? this.tiposSolicitud,
          zona: zona ?? this.zona,
          zonas: zonas ?? this.zonas,
          loading: loading ?? this.loading);

  @override
  List<Object?> get props =>
      [descripcion, tipoSolicitud, zona, tiposSolicitud, zonas, loading];
}
