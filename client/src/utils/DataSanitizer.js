exports.cleanJobsData = (data) => {
    let sanitizedData = [];

    data.forEach((d) => {
        sanitizedData.push({
            id: d.jobId,
            title: d.title,
            startdate: this.date(d.startDate),
            enddate: this.date(d.endDate),
            status: d.isComplete ? "Complete" : "In Progress"
        });
    });

    return sanitizedData;
}

exports.cleanClientsData = (data) => {
    let sanitizedData = [];

    data.forEach((d) => {
        sanitizedData.push({
            id: d.clientId,
            name: d.clientName,
            email: d.clientEmail,
            phone: d.clientPhoneNumber,
            location: `${d.clientCity}, ${d.clientState}`
        });
    });

    return sanitizedData;
}

exports.cleanLabourersData = (data) => {
    let sanitizedData = [];

    data.forEach((d) => {
        sanitizedData.push({
            id: d.labourerId,
            name: `${d.labourerFirstName} ${d.labourerLastName}`,
            email: d.labourerEmail,
            availability: d.isAvailable ? "Yes" : "No"
        });
    });

    return sanitizedData;
}

exports.cleanIncidentsData = (data) => {
    let sanitizedData = [];

    data.forEach((d) => {
        sanitizedData.push({
            id: d.incidentReportId,
            job: d.job.title,
            date: this.date(d.incidentReportDate),
            type: d.incidentType.incidentTypeName,
            affected: `${d.labourerIncidentReport.length} labourer(s)`
        });
    });

    return sanitizedData;
}

exports.cleanPayratesData = (data) => {
    let sanitizedData = [];

    data.forEach((d) => {
        let rate = (Math.floor(Math.random() * 10) + 20).toFixed(2);
        let adminRate = (rate * 1.2).toFixed(2); 
        sanitizedData.push({
            id: d.skillId,
            name: d.skillName,
            labourerReceives: `$${rate}/hr`,
            adminReceives: `$${adminRate}/hr`
        });
    });

    return sanitizedData;
}

exports.date = (date) => {
    let d = new Date(date);

    const months = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
        'July',
        'August',
        'September',
        'October',
        'November',
        'December'
    ];
    
    return `${months[d.getMonth()]} ${d.getDate()}, ${d.getFullYear()}`;
}

exports.phone = (p) => {
    let cleaned = ('' + p).replace(/\D/g, '');
    let match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);
    return match ? '(' + match[1] + ') ' + match[2] + '-' + match[3] : p;
}