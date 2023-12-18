import 'package:equatable/equatable.dart';
import 'package:movilapp/modules/solicitud/model/solicitud_model.dart';

class HomeState extends Equatable {
  final List<SolicitudModel> solicitudes;

  const HomeState({required this.solicitudes});

  HomeState copyWith({List<SolicitudModel>? solicitudes}) =>
      HomeState(solicitudes: solicitudes ?? this.solicitudes);

  @override
  List<Object?> get props => [solicitudes];
}
