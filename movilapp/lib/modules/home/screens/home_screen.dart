import 'package:flutter/material.dart';
import 'package:movilapp/modules/home/screens/controller/home_controller.dart';
import 'package:movilapp/modules/solicitud/widgets/solicitud_card.dart';
import 'package:movilapp/modules/usuario/controller/usuario_controller.dart';
import 'package:movilapp/routes/routes.dart';
import 'package:provider/provider.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((_) {
      context.read<UsuarioController>().init();
      context.read<HomeController>().obtenerSolicitudes();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: Drawer(
          child: ListView(
            children: [
              Consumer<UsuarioController>(
                builder: (context, value, child) {
                  final nombreUsuario = value.state.usuario.nombre;
                  final apellidoUsuario = value.state.usuario.apellido;
                  final codigoUsuario = value.state.usuario.codigo;
                  final imagenUsuario = value.state.usuario.urlImagen;
                  Widget usuarioImagen = Text(nombreUsuario.substring(0, 1) +
                      apellidoUsuario.substring(0, 1));

                  if (imagenUsuario != null) {
                    usuarioImagen = ClipOval(
                      child: Image.network(imagenUsuario),
                    );
                  }

                  return UserAccountsDrawerHeader(
                    accountName: Text("$nombreUsuario $apellidoUsuario"),
                    accountEmail: Text(codigoUsuario),
                    currentAccountPicture: CircleAvatar(
                      child: usuarioImagen,
                    ),
                  );
                },
              ),
              const ListTile(
                leading: Icon(Icons.add),
                title: Text("Crear solicitud"),
              ),
              ListTile(
                leading: const Icon(Icons.arrow_back),
                title: const Text("Cerrar sesión"),
                onTap: () async {
                  await context.read<UsuarioController>().cerrarSesion();
                  if (context.mounted) {
                    Navigator.popUntil(
                        context, ModalRoute.withName(Routes.login));
                  }
                },
              ),
            ],
          ),
        ),
        appBar: AppBar(
          title: const Text("Home"),
          backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        ),
        body: Consumer<HomeController>(
          builder: (context, value, child) {
            final solicitudes = value.state.solicitudes;
            if (solicitudes.isEmpty) {
              return const Center(
                child: Text("No tiene solicitudes"),
              );
            }

            return Padding(
              padding: const EdgeInsets.all(15),
              child: RefreshIndicator(
                onRefresh: context.read<HomeController>().obtenerSolicitudes,
                child: ListView.builder(
                  itemBuilder: (context, index) {
                    return SolicitudCard(
                      solicitud: solicitudes[index],
                    );
                  },
                  itemCount: solicitudes.length,
                ),
              ),
            );
          },
        ));
  }
}
