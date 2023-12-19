import 'package:flutter/material.dart';
import 'package:movilapp/modules/home/screens/controller/home_controller.dart';
import 'package:movilapp/modules/home/widgets/account_drawer.dart';
import 'package:movilapp/modules/solicitud/widgets/solicitud_card.dart';
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
      context.read<HomeController>().obtenerSolicitudes();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        drawer: const AccountDrawer(),
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
