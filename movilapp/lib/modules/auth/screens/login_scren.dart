import 'package:flutter/material.dart';
import 'package:movilapp/modules/auth/screens/controllers/login_controller.dart';
import 'package:movilapp/modules/auth/screens/states/login_state.dart';
import 'package:provider/provider.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider<LoginController>(
      create: (_) => LoginController(
        const LoginState(codigo: "", password: "", loading: false),
        authenticationRepository: context.read(),
      ),
      child: Scaffold(
        appBar: AppBar(
          title: const Text("Login"),
        ),
        body: SafeArea(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Form(
              child: Builder(builder: (context) {
                return Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    TextFormField(
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'usuario',
                      ),
                      onChanged: (text) {
                        context.read<LoginController>().onCodigoChange(text);
                      },
                      validator: (text) {
                        text = text?.trim().toLowerCase() ?? '';
                        if (text.isEmpty) {
                          return "El codigo de usuario ese necesario";
                        }
                        return null;
                      },
                    ),
                    const SizedBox(height: 20),
                    TextFormField(
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        hintText: 'password',
                      ),
                      onChanged: (text) {
                        context.read<LoginController>().onPasswordChange(text);
                      },
                      validator: (text) {
                        text = text?.trim().toLowerCase() ?? '';
                        if (text.isEmpty) {
                          return "La contraseña es obligatoria";
                        }
                        return null;
                      },
                    ),
                    const SizedBox(height: 20),
                    Selector<LoginController, bool>(
                      selector: (_, state) => state.state.loading,
                      builder: (context, value, child) {
                        if (value) {
                          return const CircularProgressIndicator();
                        }

                        return ElevatedButton(
                          onPressed: () async {
                            final isValid = Form.of(context).validate();
                            if (isValid) {
                              final loginController =
                                  context.read<LoginController>();
                              final result =
                                  await loginController.iniciarSesion();

                              result.fold(
                                (l) {
                                  ScaffoldMessenger.of(context).showSnackBar(
                                    SnackBar(
                                      content: Text(l),
                                    ),
                                  );
                                },
                                (r) => null,
                              );
                            }
                          },
                          child: value
                              ? const CircularProgressIndicator()
                              : const Text("Iniciar sesión"),
                        );
                      },
                    ),
                  ],
                );
              }),
            ),
          ),
        ),
      ),
    );
  }
}
