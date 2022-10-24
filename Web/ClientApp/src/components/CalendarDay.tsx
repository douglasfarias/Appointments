import { useState } from "react";
import {
	Button,
	Col,
	Container,
	Dropdown,
	DropdownMenu,
	DropdownToggle,
	Form,
	FormGroup,
	Input,
	Label,
	Modal,
	ModalBody,
	ModalHeader,
	Row,
} from "reactstrap";
import CalendarEventList from "./CalendarEventList";

export type CalendarDayProps = {
	day: number;
	addEvent?: () => void;
};

const CalendarDay = (props: CalendarDayProps) => {
	return (
		<Container
			fluid
			className="border pb-2 pt-2 bg-dark text-light col-sm-12 col-md-6 col-lg-4 border-secondary">
			<Row>
				<Col className="justify-content-center align-items-center">
					<strong>Dia </strong>
					<span>{props.day + 1}</span>
				</Col>
			</Row>
			<Row>
				<Col className="ml-1 mr-1">
					<Row>
						<CalendarEventList
							events={[
								{
									customer: "Luísa Sonza",
									services: ["Escova", "Hidratação"],
									date: new Date(),
								},
								{
									customer: "Anita Silva",
									services: [
										"Escova",
										"Hidratação",
										"Pé",
										"Mão",
										"Maquiagem",
										"Máscara de abacate",
									],
									date: new Date(),
								},
							]}
						/>
					</Row>
				</Col>
			</Row>
		</Container>
	);
};

export default CalendarDay;
