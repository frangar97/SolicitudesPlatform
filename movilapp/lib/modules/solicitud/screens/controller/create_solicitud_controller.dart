import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/global/state_notifier.dart';
import 'package:movilapp/modules/solicitud/repository/solicitud_repository.dart';
import 'package:movilapp/modules/solicitud/screens/state/create_solicitud_state.dart';

class CreateSolicitudController extends StateNotifier<CreateSolicitudState> {
  CreateSolicitudController(super.state,
      {required this.solicitudRepository, required this.flutterSecureStorage});

  final SolicitudRepository solicitudRepository;
  FlutterSecureStorage flutterSecureStorage;

  Future<void> init() async {
    final token = await flutterSecureStorage.read(key: "token");
    final resultTipos = await solicitudRepository.obtenerTiposSolicitud(token!);
    final resultZonas = await solicitudRepository.obtenerZonas(token);

    resultTipos.fold((l) => null, (r) {
      updateAndNotify(state.copyWith(tiposSolicitud: r));
    });

    resultZonas.fold((l) => null, (r) {
      updateAndNotify(state.copyWith(zonas: r));
    });
  }
}
