import { useState } from "react";
import { Button, Container, Dropdown, DropdownMenu, DropdownToggle, Row } from "reactstrap";

export type CalendarEventProps = {
	event: {
		services: string[];
		customer: string;
		date: Date;
	};
};

const CalendarEvent = (props: CalendarEventProps) => {
	const [dropdownEventOpen, setDropdownEventOpen] = useState(false);

	const toggleDropdownEvent = () => setDropdownEventOpen((prevState) => !prevState);

	return (
		<tr>
			<th scope="row">
				<small>
					<strong>{props.event.date.toLocaleTimeString("pt-br")}</strong>
				</small>
			</th>
			<td>
				<small>{props.event.customer}</small>
			</td>
			<td>
				<Dropdown
					isOpen={dropdownEventOpen}
					toggle={toggleDropdownEvent}
					direction={"left"}>
					<DropdownToggle size="sm" color="dark" className="text-primary">
						<i className="bi bi-three-dots"></i>
					</DropdownToggle>
					<DropdownMenu className="bg-secondary">
						<Container>
							<Row className="justify-content-around align-content-around">
								<Button color="primary" size="sm" className="rounded-circle">
									<i className="bi bi-pencil"></i>
								</Button>
								<Button color="danger" size="sm" className="rounded-circle">
									<i className="bi bi-trash"></i>
								</Button>
								<Button color="info" size="sm" className="rounded-circle">
									<i className="bi bi-info"></i>
								</Button>
							</Row>
						</Container>
					</DropdownMenu>
				</Dropdown>
			</td>
		</tr>
	);
};

export default CalendarEvent;
