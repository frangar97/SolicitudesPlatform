import 'package:dartz/dartz.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:movilapp/modules/global/state_notifier.dart';
import 'package:movilapp/modules/home/screens/state/home_state.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';
import 'package:movilapp/modules/solicitud/repository/solicitud_repository.dart';

class HomeController extends StateNotifier<HomeState> {
  HomeController(super.state,
      {required this.solicitudRepository, required this.flutterSecureStorage});

  final SolicitudRepository solicitudRepository;
  FlutterSecureStorage flutterSecureStorage;

  Future<Either<String, List<SolicitudModel>>> obtenerSolicitudes() async {
    final token = await flutterSecureStorage.read(key: "token");
    final result = await solicitudRepository.obtenerSolicitudesUsuario(token!);

    result.fold((l) => null, (r) {
      updateAndNotify(state.copyWith(solicitudes: r));
    });

    return result;
  }
}
