import 'package:equatable/equatable.dart';

class GeneroModel extends Equatable {
  final int id;
  final String tipo;

  const GeneroModel({required this.id, required this.tipo});

  factory GeneroModel.fromJson(Map<String, dynamic> json) =>
      GeneroModel(id: json["id"], tipo: json["tipo"]);

  @override
  List<Object?> get props => [];
}
