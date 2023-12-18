import 'package:equatable/equatable.dart';
import 'package:movilapp/modules/usuario/model/usuario_model.dart';

class UsuarioState extends Equatable {
  final UsuarioModel usuario;

  const UsuarioState({required this.usuario});

  UsuarioState copyWith({UsuarioModel? usuario}) =>
      UsuarioState(usuario: usuario ?? this.usuario);

  @override
  List<Object?> get props => [usuario];
}
