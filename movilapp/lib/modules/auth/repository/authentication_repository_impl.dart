import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:dartz/dartz.dart';
import 'package:movilapp/constants/constants.dart';
import 'package:movilapp/modules/auth/model/genero_model.dart';
import 'package:movilapp/modules/auth/model/login_model.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';

class AuthenticationRepositoryImpl implements AuthenticationRepository {
  final http.Client client;

  AuthenticationRepositoryImpl({required this.client});

  @override
  Future<Either<String, String>> login(LoginModel loginModel) async {
    try {
      final url = Uri.parse("$apiUrl/api/auth/login");

      final response = await client.post(url,
          body: jsonEncode(loginModel),
          headers: {"Content-Type": "application/json"});

      if (response.statusCode == 200) {
        final decodedResponse = jsonDecode(response.body);
        return Right(decodedResponse["token"]);
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left("Ocurrio un error y no se pudo iniciar sesión");
    }
  }

  @override
  Future<Either<String, List<GeneroModel>>> obtenerGeneros() async {
    try {
      final url = Uri.parse("$apiUrl/api/auth/generos");

      final response =
          await client.get(url, headers: {"Content-Type": "application/json"});

      if (response.statusCode == 200) {
        Iterable decodedResp = jsonDecode(response.body);
        List<GeneroModel> generos = List<GeneroModel>.from(
          decodedResp.map(
            (e) => GeneroModel.fromJson(e),
          ),
        );
        return Right(generos);
      } else {
        final decodedResponse = jsonDecode(response.body);
        return Left(decodedResponse["detail"]);
      }
    } catch (err) {
      return const Left("Ocurrio un error y no se pudo iniciar sesión");
    }
  }
}