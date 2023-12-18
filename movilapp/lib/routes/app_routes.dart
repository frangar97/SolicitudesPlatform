import 'package:flutter/material.dart';
import 'package:movilapp/modules/auth/screens/login_scren.dart';
import 'package:movilapp/modules/auth/screens/register_screen.dart';
import 'package:movilapp/modules/home/screens/home_screen.dart';
import 'package:movilapp/routes/routes.dart';

Map<String, Widget Function(BuildContext)> get appRoutes {
  return {
    Routes.login: (_) => const LoginScreen(),
    Routes.register: (_) => const RegisterScreen(),
    Routes.home: (_) => const HomeScreen(),
  };
}
