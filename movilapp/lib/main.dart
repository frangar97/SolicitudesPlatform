import 'package:flutter/material.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository.dart';
import 'package:movilapp/modules/auth/repository/authentication_repository_impl.dart';
import 'package:movilapp/routes/app_routes.dart';
import 'package:movilapp/routes/routes.dart';
import 'package:provider/provider.dart';
import 'package:http/http.dart' as http;

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        Provider<AuthenticationRepository>(
          create: (_) => AuthenticationRepositoryImpl(
            client: http.Client(),
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
    );
  }
}
