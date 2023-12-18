import 'package:flutter/material.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';

class SolicitudCard extends StatelessWidget {
  final SolicitudModel solicitud;

  const SolicitudCard({Key? key, required this.solicitud}) : super(key: key);

  Widget _devolverEstadoSolicitud() {
    if (solicitud.estadoSolicitud.toUpperCase() == "APROBADO") {
      return Row(
        children: [
          const Icon(
            Icons.check,
            color: Colors.green,
          ),
          Text(solicitud.estadoSolicitud)
        ],
      );
    }

    if (solicitud.estadoSolicitud.toUpperCase() == "CANCELADO") {
      return Row(
        children: [
          const Icon(
            Icons.cancel,
            color: Colors.red,
          ),
          Text(solicitud.estadoSolicitud)
        ],
      );
    }

    return Row(
      children: [
        const Icon(
          Icons.timer,
          color: Colors.orange,
        ),
        Text(solicitud.estadoSolicitud)
      ],
    );
  }

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Tipo: ${solicitud.tipoSolicitud}",
                  style: const TextStyle(fontWeight: FontWeight.bold),
                ),
                Text(
                  "Zona: ${solicitud.zona}",
                  style: const TextStyle(fontWeight: FontWeight.bold),
                ),
              ],
            ),
            const SizedBox(height: 20),
            Text(solicitud.descripcion),
            const SizedBox(height: 20),
            Row(
              children: [_devolverEstadoSolicitud()],
            )
          ],
        ),
      ),
    );
  }
}
