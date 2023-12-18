import { FC } from "react";
import { IUsuario } from "../interface/IUsuario";


export const UsuarioTable: FC<{ usuarios: IUsuario[] }> = ({ usuarios }) => {
    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Genero</th>
                    <th>Tipo Usuario</th>
                    <th>Imagen</th>
                </tr>
            </thead>
            <tbody>
                {usuarios.map((u) => (
                    <tr key={u.id}>
                        <td>{u.nombre}</td>
                        <td>{u.apellido}</td>
                        <td>{u.genero}</td>
                        <td>{u.tipoUsuario}</td>
                        <td>{(u.urlImagen === null) ? "No disponible" : <img style={{ width: 125, height: 125 }} src={u.urlImagen} className="img-thumbnail" />}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}