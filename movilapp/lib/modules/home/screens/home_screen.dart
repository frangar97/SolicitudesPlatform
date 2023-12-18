import 'package:flutter/material.dart';
import 'package:movilapp/modules/usuario/controller/usuario_controller.dart';
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
            const ListTile(
              leading: Icon(Icons.arrow_back),
              title: Text("Cerrar sesión"),
            ),
          ],
        ),
      ),
      appBar: AppBar(
        title: const Text("Home"),
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
      ),
    );
  }
}
