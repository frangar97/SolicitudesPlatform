import { FC } from "react";
import { ISolicitud } from "../interface/ISolicitud";

interface ISolicitudTable {
    solicitudes: ISolicitud[],
    estado: 'Pendiente' | 'Aprobado' | 'Cancelado',
    aprobarSolicitud: (id: number) => void,
    cancelarSolicitud: (id: number) => void
}

export const SolicitudTable: FC<ISolicitudTable> = ({ solicitudes, estado, aprobarSolicitud, cancelarSolicitud }) => {

    const tipoBadge = () => {
        let tipo = "";

        switch (estado) {
            case 'Aprobado':
                tipo = "badge bg-success";
                break;
            case 'Cancelado':
                tipo = "badge bg-danger";
                break;
            case 'Pendiente':
                tipo = "badge bg-warning";
                break;
            default:
                tipo = "badge bg-warning";
                break;
        }

        return tipo;
    }

    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Usuario</th>
                    <th>Estado</th>
                    <th>Tipo</th>
                    <th>Zona</th>
                    {estado === "Pendiente" ? <th>Acciones</th> : null}
                </tr>
            </thead>
            <tbody>
                {solicitudes.map((u) => (
                    <tr key={u.id}>
                        <td>{u.descripcion}</td>
                        <td>{u.usuario}</td>
                        <td><span className={tipoBadge()}>{u.estadoSolicitud}</span></td>
                        <td>{u.tipoSolicitud}</td>
                        <td>{u.zona}</td>
                        {estado === "Pendiente" ?
                            <th>
                                <button className="btn btn-success" onClick={() => aprobarSolicitud(u.id)}>aprobar</button>
                                <button style={{ marginLeft: 5 }} className="btn btn-danger" onClick={() => cancelarSolicitud(u.id)}>cancelar</button>
                            </th>
                            : null}
                    </tr>
                ))}
            </tbody>
        </table>
    )
}