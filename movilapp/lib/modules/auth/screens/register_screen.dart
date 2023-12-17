import 'package:flutter/material.dart';
import 'package:movilapp/modules/auth/screens/controllers/register_controller.dart';
import 'package:movilapp/modules/auth/screens/states/register_state.dart';
import 'package:provider/provider.dart';

class RegisterScreen extends StatelessWidget {
  const RegisterScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (_) => RegisterController(
          const RegisterState(
            codigo: "",
            password: "",
            loading: false,
            apellido: "",
            genero: "",
            nombre: "",
            tipoUsuario: "",
            generos: [],
          ),
          authenticationRepository: context.read())
        ..init(),
      child: Scaffold(
        appBar: AppBar(
          title: const Text("Registro"),
          backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        ),
        body: SafeArea(
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Form(
              child: Builder(
                builder: (context) {
                  return SingleChildScrollView(
                    child: Column(
                      children: [
                        TextFormField(
                          decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: 'nombre',
                          ),
                          onChanged: (text) {},
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "El nombre es necesario";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 10),
                        TextFormField(
                          decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: 'apellido',
                          ),
                          onChanged: (text) {},
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "El apellido es necesario";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 10),
                        TextFormField(
                          decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: 'codigo',
                          ),
                          onChanged: (text) {},
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "El codigo es necesario";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 10),
                        TextFormField(
                          decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: 'password',
                          ),
                          onChanged: (text) {},
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "El password es necesario";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 10),
                        const Text(
                          "Seleccione el genero:",
                        ),
                        SizedBox(
                          height: 100,
                          child: Consumer<RegisterController>(
                            builder: (context, value, child) {
                              return ListView.builder(
                                itemBuilder: (context, index) {
                                  final genero =
                                      value.state.generos[index].tipo;

                                  return RadioListTile<String>(
                                    title: Text(genero),
                                    value: genero,
                                    groupValue: value.state.genero,
                                    onChanged: (_) => context
                                        .read<RegisterController>()
                                        .onGeneroChange(genero),
                                  );
                                },
                                itemCount: value.state.generos.length,
                              );
                            },
                          ),
                        )
                      ],
                    ),
                  );
                },
              ),
            ),
          ),
        ),
      ),
    );
  }
}
