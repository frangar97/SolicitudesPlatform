import 'package:dartz/dartz.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/global/state_notifier.dart';
import 'package:movilapp/modules/solicitud/model/create_solicitud_model.dart';
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

  void onChangeDescripcion(String descripcion) {
    onlyUpdate(state.copyWith(descripcion: descripcion));
  }

  void onChangeZona(String zona) {
    onlyUpdate(state.copyWith(zona: zona));
  }

  void onChangeTipoSolicitud(String tipoSolicitud) {
    onlyUpdate(state.copyWith(tipoSolicitud: tipoSolicitud));
  }

  Future<Either<String, String>> crearSolicitud() async {
    updateAndNotify(state.copyWith(loading: true));
    final token = await flutterSecureStorage.read(key: "token");
    final solicitud = CreateSolicitudModel(
        descripcion: state.descripcion,
        tipoSolicitud: state.tipoSolicitud,
        zona: state.zona);
    final result = await solicitudRepository.crearSolicitud(solicitud, token!);
    updateAndNotify(state.copyWith(loading: false));

    return result;
  }
}
