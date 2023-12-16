import { FC } from "react";
import { ITipoSolicitud } from "../interface/ITipoSolicitud";

interface ITipoSolicitudTable {
    tipoSolicitudes: ITipoSolicitud[],
}

export const TipoSolicitudTable: FC<ITipoSolicitudTable> = ({ tipoSolicitudes }) => {

    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Tipo</th>
                </tr>
            </thead>
            <tbody>
                {tipoSolicitudes.map((u) => (
                    <tr key={u.id}>
                        <td>{u.id}</td>
                        <td>{u.tipo}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}