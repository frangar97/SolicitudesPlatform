import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:movilapp/constants/constants.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';
import 'package:movilapp/modules/solicitud/repository/solicitud_repository.dart';
import 'package:http/http.dart' as http;

class SolicitudRepositoryImpl implements SolicitudRepository {
  final http.Client client;
  SolicitudRepositoryImpl({required this.client});

  @override
  Future<Either<String, List<SolicitudModel>>> obtenerSolicitudesUsuario(
      String token) async {
    try {
      final url = Uri.parse("$apiUrl/api/solicitud/usuario");

      final response = await client.get(url, headers: {
        "Content-Type": "application/json",
        "Authentication": "Bearer $token"
      });

      if (response.statusCode == 200) {
        Iterable decodedResp = jsonDecode(response.body);
        List<SolicitudModel> solicitudes = List<SolicitudModel>.from(
          decodedResp.map(
            (e) => SolicitudModel.fromJson(e),
          ),
        );
        return Right(solicitudes);
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left("Ocurrio un error y no se pudo iniciar sesión");
    }
  }
}
