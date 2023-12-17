import 'package:equatable/equatable.dart';

class TipoUsuarioModel extends Equatable {
  final int id;
  final String tipo;

  const TipoUsuarioModel({required this.id, required this.tipo});

  factory TipoUsuarioModel.fromJson(Map<String, dynamic> json) =>
      TipoUsuarioModel(id: json["id"], tipo: json["tipo"]);

  @override
  List<Object?> get props => [];
}
