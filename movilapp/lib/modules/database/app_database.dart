import 'dart:async';
import 'package:floor/floor.dart';
import 'package:sqflite/sqflite.dart' as sqflite;
import 'package:movilapp/modules/usuario/database/usuario_dao.dart';
import 'package:movilapp/modules/usuario/database/usuario_entity.dart';

part 'app_database.g.dart';

@Database(
  version: 1,
  entities: [
    UsuarioEntity,
  ],
)
abstract class AppDatabase extends FloorDatabase {
  UsuarioDao get usuarioDao;
}
