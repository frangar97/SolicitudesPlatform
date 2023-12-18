import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository_impl.dart';
import 'package:movilapp/modules/usuario/controller/usuario_controller.dart';
import 'package:movilapp/modules/usuario/model/usuario_model.dart';
import 'package:movilapp/modules/usuario/state/usuario_state.dart';

import 'package:movilapp/routes/app_routes.dart';
import 'package:movilapp/routes/routes.dart';
import 'package:provider/provider.dart';
import 'package:http/http.dart' as http;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();

  runApp(MultiProvider(
    providers: [
      Provider<AuthenticationRepository>(
        create: (_) => AuthenticationRepositoryImpl(
          client: http.Client(),
        ),
      ),
      ChangeNotifierProvider<UsuarioController>(
        create: (context) => UsuarioController(
          const UsuarioState(
            usuario: UsuarioModel(
              apellido: "",
              codigo: "",
              genero: "",
              nombre: "",
              tipoUsuario: "",
              id: 0,
            ),
          ),
          flutterSecureStorage: const FlutterSecureStorage(),
          authenticationRepository: context.read(),
        ),
      ),
    ],
    child: MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      routes: appRoutes,
      initialRoute: Routes.login,
    ),
  ));
}
