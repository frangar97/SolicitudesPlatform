import 'package:dartz/dartz.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';

abstract class SolicitudRepository {
  Future<Either<String, List<SolicitudModel>>> obtenerSolicitudesUsuario(
      String token);
}
