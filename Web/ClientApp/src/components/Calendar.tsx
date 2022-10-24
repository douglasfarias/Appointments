import { useState } from "react";
import { Button, Col, Container, Row } from "reactstrap";
import "./Calendar.tsx.css";
import CalendarDay from "./CalendarDay";

const Calendar = () => {
	const [state, setState] = useState<{
		date: Date;
	}>({
		date: new Date(),
	});

	const getDaysInMonth = () => [
		...Array(new Date(state.date.getFullYear(), state.date.getMonth() + 1, 0).getDate()).keys(),
	];

	const decrementMonth = () => {
		const date = new Date();
		date.setMonth(state.date.getMonth() - 1);
		setState({ date });
	};

	const incrementMonth = () => {
		const date = new Date();
		date.setMonth(state.date.getMonth() + 1);
		setState({ date });
	};

	return (
		<>
			<h3 className="text-center captiled-text">
				{state.date.toLocaleString("pt-br", { month: "long" })}
			</h3>
			<Container fluid>
				<Row className="justify-content-between align-content-between p-3">
					<Button color="dark" onClick={decrementMonth} className="text-primary">
						<i className="bi bi-chevron-left"></i>Mês Anterior
					</Button>
					<Button color="dark" onClick={incrementMonth} className="text-primary">
						Próximo Mês<i className="bi bi-chevron-right"></i>
					</Button>
				</Row>
			</Container>
			<Container fluid>
				<Row>
					{getDaysInMonth().map((day) => (
						<CalendarDay key={day} day={day} />
					))}
				</Row>
			</Container>
		</>
	);
};

export default Calendar;
