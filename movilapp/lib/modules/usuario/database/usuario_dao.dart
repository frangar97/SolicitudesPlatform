import 'package:floor/floor.dart';
import 'package:movilapp/modules/usuario/database/usuario_entity.dart';

@dao
abstract class UsuarioDao {
  @Query("SELECT * FROM Usuario WHERE codigo = :codigo LIMIT 1")
  Future<UsuarioEntity?> findByCodigo(String codigo);

  @insert
  Future<void> insertUsuario(UsuarioEntity usuarioEntity);

  @insert
  Future<void> updateUsuario(UsuarioEntity usuarioEntity);
}
