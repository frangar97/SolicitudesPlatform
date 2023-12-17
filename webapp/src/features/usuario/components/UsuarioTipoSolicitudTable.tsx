import { FC } from "react";
import { ITipoSolicitud } from "../../solicitud/interface/ITipoSolicitud";


interface IUsuarioTipoSolicitudTable {
    tiposSolicitud: ITipoSolicitud[],
    tipo: "asignar" | "remover",
    accion: (zonaId: number) => void
}

export const UsuarioTipoSolicitudTable: FC<IUsuarioTipoSolicitudTable> = ({ tiposSolicitud, tipo, accion }) => {
    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Tipo</th>
                    <th>Accion</th>
                </tr>
            </thead>
            <tbody>
                {tiposSolicitud.map((u) => (
                    <tr key={u.id}>
                        <td>{u.id}</td>
                        <td>{u.tipo}</td>
                        <td><button onClick={() => accion(u.id)} className={`btn btn-${tipo === "asignar" ? "success" : "danger"}`}>{tipo === "asignar" ? "Asignar" : "Remover"}</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}