import 'dart:io';

import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:movilapp/modules/auth/screens/controllers/register_controller.dart';
import 'package:movilapp/modules/auth/screens/states/register_state.dart';
import 'package:movilapp/routes/routes.dart';
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
              tiposUsuario: []),
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
                          onChanged: (text) {
                            context
                                .read<RegisterController>()
                                .onNombreChange(text);
                          },
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
                          onChanged: (text) {
                            context
                                .read<RegisterController>()
                                .onApellidoChange(text);
                          },
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
                          onChanged: (text) {
                            context
                                .read<RegisterController>()
                                .onCodigoChange(text);
                          },
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
                          obscureText: true,
                          decoration: const InputDecoration(
                            border: OutlineInputBorder(),
                            hintText: 'password',
                          ),
                          onChanged: (text) {
                            context
                                .read<RegisterController>()
                                .onPasswordChange(text);
                          },
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "La password es necesario";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 10),
                        const Text(
                          "Seleccione el genero:",
                        ),
                        Consumer<RegisterController>(
                          builder: (context, value, child) {
                            final generos = value.state.generos;
                            return DropdownButtonFormField<String>(
                                value: value.state.genero,
                                items:
                                    List.generate(generos.length + 1, (index) {
                                  if (index == 0) {
                                    return const DropdownMenuItem(
                                      value: "",
                                      child: Text(""),
                                    );
                                  }
                                  return DropdownMenuItem(
                                    value: generos[index - 1].tipo,
                                    child: Text(generos[index - 1].tipo),
                                  );
                                }),
                                onChanged: (opcion) {
                                  if (opcion != null) {
                                    context
                                        .read<RegisterController>()
                                        .onGeneroChange(opcion);
                                  }
                                },
                                validator: (text) {
                                  text = text?.trim().toLowerCase() ?? '';
                                  if (text.isEmpty) {
                                    return "El genero es necesario";
                                  }
                                  return null;
                                });
                          },
                        ),
                        const SizedBox(height: 10),
                        const Text(
                          "Seleccione el tipo de usuario:",
                        ),
                        Consumer<RegisterController>(
                          builder: (context, value, child) {
                            final tiposUsuario = value.state.tiposUsuario;
                            return DropdownButtonFormField<String>(
                                value: value.state.tipoUsuario,
                                items: List.generate(tiposUsuario.length + 1,
                                    (index) {
                                  if (index == 0) {
                                    return const DropdownMenuItem(
                                      value: "",
                                      child: Text(""),
                                    );
                                  }
                                  return DropdownMenuItem(
                                    value: tiposUsuario[index - 1].tipo,
                                    child: Text(tiposUsuario[index - 1].tipo),
                                  );
                                }),
                                onChanged: (opcion) {
                                  if (opcion != null) {
                                    context
                                        .read<RegisterController>()
                                        .onTipoUsuarioChange(opcion);
                                  }
                                },
                                validator: (text) {
                                  text = text?.trim().toLowerCase() ?? '';
                                  if (text.isEmpty) {
                                    return "El tipo de usuario es necesario";
                                  }
                                  return null;
                                });
                          },
                        ),
                        const SizedBox(height: 10),
                        ElevatedButton(
                          onPressed: () async {
                            final imagenSeleccionada = await ImagePicker()
                                .pickImage(source: ImageSource.gallery);
                            if (context.mounted) {
                              if (imagenSeleccionada != null) {
                                context
                                    .read<RegisterController>()
                                    .onChangeImage(
                                        File(imagenSeleccionada.path));
                              }
                            }
                          },
                          child: const Text("Seleccionar imagen de galeria"),
                        ),
                        const SizedBox(height: 10),
                        Selector<RegisterController, bool>(
                          selector: (_, state) => state.state.loading,
                          builder: (context, value, child) {
                            if (value) {
                              return const CircularProgressIndicator();
                            }

                            return ElevatedButton(
                              onPressed: () async {
                                final isValid = Form.of(context).validate();
                                if (isValid) {
                                  final registerController =
                                      context.read<RegisterController>();

                                  if (registerController.state.genero == "" ||
                                      registerController.state.tipoUsuario ==
                                          "") {
                                    ScaffoldMessenger.of(context).showSnackBar(
                                      const SnackBar(
                                        content: Text("Seleccione una opcion"),
                                      ),
                                    );

                                    return;
                                  }

                                  final result = await registerController
                                      .registrarUsuario();

                                  result.fold(
                                    (l) {
                                      ScaffoldMessenger.of(context)
                                          .showSnackBar(
                                        SnackBar(
                                          content: Text(l),
                                        ),
                                      );
                                    },
                                    (r) => Navigator.pushReplacementNamed(
                                        context, Routes.login),
                                  );
                                }
                              },
                              child: const Text("Registrar"),
                            );
                          },
                        ),
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
