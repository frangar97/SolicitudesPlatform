import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/tipo_solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/zona_model.dart';

abstract class SolicitudRepository {
  Future<Either<String, List<SolicitudModel>>> obtenerSolicitudesUsuario(
      String token);
  Future<Either<String, List<TipoSolicitudModel>>> obtenerTiposSolicitud(
      String token);
  Future<Either<String, List<ZonaModel>>> obtenerZonas(String token);
}
