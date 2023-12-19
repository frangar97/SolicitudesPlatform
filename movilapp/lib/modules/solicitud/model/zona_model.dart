import 'package:equatable/equatable.dart';

class ZonaModel extends Equatable {
  final int id;
  final String nombre;

  const ZonaModel({required this.id, required this.nombre});

  factory ZonaModel.fromJson(Map<String, dynamic> json) =>
      ZonaModel(id: json["id"], nombre: json["nombre"]);

  @override
  List<Object?> get props => [id, nombre];
}
