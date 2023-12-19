import 'dart:convert';

import 'package:dartz/dartz.dart';
import 'package:movilapp/constants/constants.dart';
import 'package:movilapp/modules/solicitud/model/create_solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/tipo_solicitud_model.dart';
import 'package:movilapp/modules/solicitud/model/zona_model.dart';
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
        "Authorization": "Bearer $token"
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
      return const Left(
          "Ocurrio un error y no se pudo obtener las solicitudes del usuario");
    }
  }

  @override
  Future<Either<String, List<TipoSolicitudModel>>> obtenerTiposSolicitud(
      String token) async {
    try {
      final url = Uri.parse("$apiUrl/api/solicitud/tipos");

      final response = await client.get(url, headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer $token"
      });

      if (response.statusCode == 200) {
        Iterable decodedResp = jsonDecode(response.body);
        List<TipoSolicitudModel> solicitudes = List<TipoSolicitudModel>.from(
          decodedResp.map(
            (e) => TipoSolicitudModel.fromJson(e),
          ),
        );
        return Right(solicitudes);
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left(
          "Ocurrio un error y no se pudo obtener los tipos de solicitud");
    }
  }

  @override
  Future<Either<String, List<ZonaModel>>> obtenerZonas(String token) async {
    try {
      final url = Uri.parse("$apiUrl/api/zona");

      final response = await client.get(url, headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer $token"
      });

      if (response.statusCode == 200) {
        Iterable decodedResp = jsonDecode(response.body);
        List<ZonaModel> solicitudes = List<ZonaModel>.from(
          decodedResp.map(
            (e) => ZonaModel.fromJson(e),
          ),
        );
        return Right(solicitudes);
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left("Ocurrio un error y no se pudo obtener las zonas");
    }
  }

  @override
  Future<Either<String, String>> crearSolicitud(
      CreateSolicitudModel solicitudModel, String token) async {
    try {
      final url = Uri.parse("$apiUrl/api/solicitud");

      final response = await client.post(url,
          body: jsonEncode(solicitudModel.toJson()),
          headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer $token"
          });

      if (response.statusCode == 200) {
        return const Right("Solicitud creada con exito");
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left("Ocurrio un error y no se pudo crear la solicitud");
    }
  }
}
