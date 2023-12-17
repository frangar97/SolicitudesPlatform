import { FC } from "react";
import { IZona } from "../interface/IZona";

interface IUsuarioZonaTable {
    zonas: IZona[],
    tipo: "asignar" | "remover",
    accion: (zonaId: number) => void
}

export const UsuarioZonaTable: FC<IUsuarioZonaTable> = ({ zonas, tipo, accion }) => {
    return (
        <table className="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Zona</th>
                    <th>Accion</th>
                </tr>
            </thead>
            <tbody>
                {zonas.map((u) => (
                    <tr key={u.id}>
                        <td>{u.id}</td>
                        <td>{u.nombre}</td>
                        <td><button onClick={() => accion(u.id)} className={`btn btn-${tipo === "asignar" ? "success" : "danger"}`}>{tipo === "asignar" ? "Asignar" : "Remover"}</button></td>
                    </tr>
                ))}
            </tbody>
        </table>
    )
}