import { useState } from "react";
import {
	Button,
	Card,
	CardBody,
	Col,
	Container,
	Dropdown,
	DropdownMenu,
	DropdownToggle,
	Row,
	Table,
} from "reactstrap";
import CalendarEvent from "./CalendarEvent";
import "./CalendarEventList.tsx.css";
export type CalendarEventProps = {
	events: Array<{
		services: string[];
		customer: string;
		date: Date;
	}>;
};

const CalendarEventList = (props: CalendarEventProps) => {
	const [dropdownOpen, setDropdownOpen] = useState(false);

	const toggle = () => setDropdownOpen((prevState) => !prevState);

	return (
		<Card color="dark" className="col-12 mt-1 mb-1 border-0">
			<CardBody className="p-1">
				<Container fluid className="p-0">
					<Row className="justify-content-end">
						<Dropdown isOpen={dropdownOpen} toggle={toggle} direction={"left"}>
							<DropdownToggle size="sm" color="dark" className="text-primary">
								<i className="bi bi-three-dots"></i>
							</DropdownToggle>
							<DropdownMenu className="bg-secondary">
								<Container>
									<Row className="justify-content-end pr-3">
										<Button
											color="success"
											size="sm"
											className="rounded-circle">
											<i className="bi bi-plus"></i>
										</Button>
									</Row>
								</Container>
							</DropdownMenu>
						</Dropdown>
					</Row>
					<Row className="pt-1">
						<Col>
							<Table className="text-light" size="sm" borderless striped responsive>
								<thead>
									<tr>
										<th scope="col">
											<small>
												<strong>Hora</strong>
											</small>
										</th>
										<th scope="col">
											<small>
												<strong>Cliente</strong>
											</small>
										</th>
										<th scope="col">
											<small>
												<strong>Ações</strong>
											</small>
										</th>
									</tr>
								</thead>
								<tbody>
									{props.events.map((item) => (
										<CalendarEvent
											key={Math.random().toString()}
											event={item}
										/>
									))}
								</tbody>
							</Table>
						</Col>
					</Row>
				</Container>
			</CardBody>
		</Card>
	);
};

export default CalendarEventList;
