import 'package:equatable/equatable.dart';

class TipoSolicitudModel extends Equatable {
  final int id;
  final String tipo;

  const TipoSolicitudModel({required this.id, required this.tipo});

  factory TipoSolicitudModel.fromJson(Map<String, dynamic> json) =>
      TipoSolicitudModel(id: json["id"], tipo: json["tipo"]);

  @override
  List<Object?> get props => [id, tipo];
}
