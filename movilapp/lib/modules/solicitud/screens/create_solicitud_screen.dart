import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/solicitud/screens/controller/create_solicitud_controller.dart';
import 'package:movilapp/modules/solicitud/screens/state/create_solicitud_state.dart';
import 'package:provider/provider.dart';

class CreateSolicitudScreen extends StatelessWidget {
  const CreateSolicitudScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (_) => CreateSolicitudController(
          const CreateSolicitudState(
            descripcion: "",
            tipoSolicitud: "",
            zona: "",
            zonas: [],
            tiposSolicitud: [],
            loading: false,
          ),
          solicitudRepository: context.read(),
          flutterSecureStorage: const FlutterSecureStorage())
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
                            hintText: 'descripcion',
                          ),
                          onChanged: (text) {
                            context
                                .read<CreateSolicitudController>()
                                .onChangeDescripcion(text);
                          },
                          validator: (text) {
                            text = text?.trim().toLowerCase() ?? '';
                            if (text.isEmpty) {
                              return "la descripcion es necesaria";
                            }
                            return null;
                          },
                        ),
                        const SizedBox(height: 30),
                        const Text(
                          "Seleccione el motivo:",
                        ),
                        Consumer<CreateSolicitudController>(
                          builder: (context, value, child) {
                            final tiposSolicitud = value.state.tiposSolicitud;
                            return DropdownButtonFormField<String>(
                                value: value.state.tipoSolicitud,
                                items: List.generate(tiposSolicitud.length + 1,
                                    (index) {
                                  if (index == 0) {
                                    return const DropdownMenuItem(
                                      value: "",
                                      child: Text(""),
                                    );
                                  }
                                  return DropdownMenuItem(
                                    value: tiposSolicitud[index - 1].tipo,
                                    child: Text(tiposSolicitud[index - 1].tipo),
                                  );
                                }),
                                onChanged: (opcion) {
                                  if (opcion != null) {
                                    context
                                        .read<CreateSolicitudController>()
                                        .onChangeTipoSolicitud(opcion);
                                  }
                                },
                                validator: (text) {
                                  text = text?.trim().toLowerCase() ?? '';
                                  if (text.isEmpty) {
                                    return "el motivo es necesario";
                                  }
                                  return null;
                                });
                          },
                        ),
                        const SizedBox(height: 30),
                        const Text(
                          "Seleccione la zona:",
                        ),
                        Consumer<CreateSolicitudController>(
                          builder: (context, value, child) {
                            final zonas = value.state.zonas;
                            return DropdownButtonFormField<String>(
                                value: value.state.zona,
                                items: List.generate(zonas.length + 1, (index) {
                                  if (index == 0) {
                                    return const DropdownMenuItem(
                                      value: "",
                                      child: Text(""),
                                    );
                                  }
                                  return DropdownMenuItem(
                                    value: zonas[index - 1].nombre,
                                    child: Text(zonas[index - 1].nombre),
                                  );
                                }),
                                onChanged: (opcion) {
                                  if (opcion != null) {
                                    context
                                        .read<CreateSolicitudController>()
                                        .onChangeZona(opcion);
                                  }
                                },
                                validator: (text) {
                                  text = text?.trim().toLowerCase() ?? '';
                                  if (text.isEmpty) {
                                    return "la zona es necesaria";
                                  }
                                  return null;
                                });
                          },
                        ),
                        const SizedBox(height: 10),
                        Selector<CreateSolicitudController, bool>(
                          selector: (_, state) => state.state.loading,
                          builder: (context, value, child) {
                            if (value) {
                              return const CircularProgressIndicator();
                            }

                            return ElevatedButton(
                              onPressed: () async {
                                final isValid = Form.of(context).validate();
                                if (isValid) {}
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
