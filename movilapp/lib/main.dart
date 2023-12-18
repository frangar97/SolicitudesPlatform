import 'package:flutter/material.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository_impl.dart';
import 'package:movilapp/modules/database/app_database.dart';
import 'package:movilapp/routes/app_routes.dart';
import 'package:movilapp/routes/routes.dart';
import 'package:provider/provider.dart';
import 'package:http/http.dart' as http;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  final database =
      await $FloorAppDatabase.databaseBuilder("solicitud.db").build();

  runApp(MultiProvider(
    providers: [
      Provider<AuthenticationRepository>(
        create: (_) => AuthenticationRepositoryImpl(
          client: http.Client(),
        ),
      ),
      Provider<AppDatabase>(
        create: (_) => database,
      )
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
