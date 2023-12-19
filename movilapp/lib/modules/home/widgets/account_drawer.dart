import 'package:flutter/material.dart';
import 'package:movilapp/modules/usuario/controller/usuario_controller.dart';
import 'package:movilapp/modules/usuario/model/usuario_model.dart';
import 'package:movilapp/routes/routes.dart';
import 'package:provider/provider.dart';

class AccountDrawer extends StatelessWidget {
  const AccountDrawer({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          Selector<UsuarioController, UsuarioModel>(
            selector: (_, controller) => controller.state.usuario,
            builder: (context, value, child) {
              final nombreUsuario = value.nombre;
              final apellidoUsuario = value.apellido;
              final codigoUsuario = value.codigo;
              final imagenUsuario = value.urlImagen;
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
          ListTile(
            leading: const Icon(Icons.add),
            title: const Text("Crear solicitud"),
            onTap: () {
              Navigator.pushNamed(context, Routes.createSolicitud);
            },
          ),
          ListTile(
            leading: const Icon(Icons.arrow_back),
            title: const Text("Cerrar sesión"),
            onTap: () async {
              await context.read<UsuarioController>().cerrarSesion();
              if (context.mounted) {
                Navigator.pushReplacementNamed(context, Routes.login);
              }
            },
          ),
        ],
      ),
    );
  }
}
