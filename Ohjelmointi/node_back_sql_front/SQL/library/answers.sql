insert into customers values (22, 'Kristian', 'Pekkanen', 'Tehtaankatu 20 A 2', 67100, 'Kokkola');

insert into loans values (22, 'Kristian', 'Pekkanen', 'Cooking Basics For Dummies', CURRENT_DATE, 'In customers posession');

select customerid, lastname, firstname, title, loandate, returned from loans;

update loans set returned = CURRENT_DATE where customerid = 22 and title = 'Engineering - U: A Guide to the Engineering Student Life';

update titles set title = 'uusi ja parempi' where titleid = 12;

insert into titles values (14, 'Ammattikorkeakoulusta selviämisen perusteet', 784578459, 'Minä', 2021, 'Minä', 3);

SELECT * FROM loans WHERE julianday(loanDate) < julianday(CURRENT_DATE) - 28;




